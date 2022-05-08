const apiBaseUrl = "https://localhost:7230/api/";
const loginApi = apiBaseUrl + "auth/login";
const registerApi = apiBaseUrl + "auth/register";
const getWiredPostApi = apiBaseUrl + "wired/getposts"
const addExamApi = apiBaseUrl + "exam/add";
const getAllExamApi = apiBaseUrl + "exam/getall";
const getExamByIdApi = apiBaseUrl + "exam/get";
const deleteExamApi = apiBaseUrl + "exam/delete";

login = () => {
    const username = $("#username").val();
    const password = $("#password").val();
    let login = false;

    let user = {
        "username": username,
        "password": password
    };

    user = JSON.stringify(user);

    $.ajax({
        type: "post",
        url: loginApi,
        contentType: "application/json",
        data: user,
        success: data => {
            login = true;
            sessionStorage.setItem("token", "Bearer " + data.token);
            sessionStorage.setItem("expires", data.expires);
            window.location = "/exam/add";
        },
        error: () => {
            Swal.fire(
                'Hata!',
                'Kullanıcı adı veya şifre hatalı!',
                'error'
            );
            login = false;
        }
    });

    return login;
}

checkSession = () => {
    var token = sessionStorage.getItem("token");
    var expires = sessionStorage.getItem("expires");
    if (token == null) {
        window.location = "/login";
        return true;
    } else {
        return false;
    }
}

getWiredPosts = () => {
    $("#select-info").text("Veriler getiriliyor. Lütfen bekleyin.");
    var index = 0;
    $.ajax({
        type: "get",
        url: getWiredPostApi,
        success: data => {
            data.forEach(element => {
                $("#exam-title").append("<option value=" + index + ">" + element.title + "</option>");
                index++;
                return data;
            });
        },
        complete: data => {
            $("#select-info").text("Sınav metnini seçin");
            selectExam(data.responseJSON);
        }
    });
}

selectExam = (exams) => {
    $("#exam-title").on("change", () => {
        var exam = exams[$("#exam-title").val()].text;
        $("#exam-text").text = exam;
        $("#exam-text").val(exam);
    });
}

setQuestionsLayout = () => {
    var layout = "";
    for (let i = 1; i <= 4; i++) {
        layout += '<div class="mb-3"><label for="question-' + i + '" class="form-label">Soru ' + i + '</label><textarea required class="form-control question-textarea" id="question-' + i + '" rows="2"></textarea></div>'
        layout += '<div class="row"><div class="col-md-6"><div class="input-group mb-3"><span class="input-group-text">A)</span><textarea id="question-' + i + '-A" required class="form-control question-option" rows="1"></textarea></div></div><div class="col-md-6"><div class="input-group mb-3"><span class="input-group-text">B)</span><textarea id="question-' + i + '-B" required class="form-control question-option" rows="1"></textarea></div></div></div>'
        layout += '<div class="row"><div class="col-md-6"><div class="input-group mb-3"><span class="input-group-text">C)</span><textarea id="question-' + i + '-C" required class="form-control question-option" rows="1"></textarea></div></div><div class="col-md-6"><div class="input-group mb-3"><span class="input-group-text">D)</span><textarea id="question-' + i + '-D" required class="form-control question-option" rows="1"></textarea></div></div></div>'
        layout += '<div class="row d-flex justify-content-center"><div class="col-md-3"><div class="row"><select required class="form-select mb-3" id="question-' + i + '-answer"><option selected disabled value="">Doğru cevabı seçin</option><option value="A">A</option><option value="B">B</option><option value="C">C</option><option value="D">D</option></select></div></div></div>';
    }
    layout += '<div class="row d-flex justify-content-center"><div class="col-md-4"><div class="row"><button type="submit" id="create-exam-button" class="btn btn-primary btn-block d-block mb-3">Sınav Oluştur</button> </div></div></div>';
    $("#exam-form").append(layout);
}

createExam = () => {
    $("#create-exam-button").on("click", () => {
        var exam = {};
        var questions = [];
        var title = $("#exam-title option:selected").text();
        var text = $("#exam-text").val();

        for (let i = 0; i < 4; i++) {
            questions.push({
                "text": $('#question-' + (i + 1)).val(),
                "optionA": $('#question-' + (i + 1) + '-A').val(),
                "optionB": $('#question-' + (i + 1) + '-B').val(),
                "optionC": $('#question-' + (i + 1) + '-C').val(),
                "optionD": $('#question-' + (i + 1) + '-D').val(),
                "keyOption": $('#question-' + (i + 1) + '-answer').val()
            });
        }

        exam = {
            "exam": {
                "title": title,
                "text": text,
                "slug": ""
            },
            "questions": questions
        };
        exam = JSON.stringify(exam);
        console.log(exam);
        $.ajax({
            type: "post",
            url: addExamApi,
            contentType: "application/json",
            data: exam,
            headers: {
                "Authorization": sessionStorage.getItem("token")
            },
            success: data => {
                window.location = "/exam/list";
            },
            error: () => {
                Swal.fire(
                    'Hata!',
                    'Bir hata oluştu. Lütfen tekrar deneyin.',
                    'error'
                );
            }
        });
    });
}

listExam = () => {
    $.ajax({
        type: "get",
        url: getAllExamApi,
        contentType: "application/json",
        headers: {
            "Authorization": sessionStorage.getItem("token")
        },
        success: data => {
            data.forEach(element => {
                $("tbody").append('<tr><th scope="row">' + element.id + '</th><td><a href="/exam/get/' + element.id + '">' + element.title + '</a></td><td>' + element.date + '</td><td><a href="/exam/delete/' + element.id + '" class="text-danger delete-exam-link">Sil</a></td></tr>');
            });
            console.log(data);
        },
        error: () => {
            Swal.fire(
                'Hata!',
                'Bir hata oluştu. Lütfen tekrar deneyin.',
                'error'
            );
        }
    });
}

getExamById = (id) => {
    $.ajax({
        type: "get",
        url: getExamByIdApi,
        contentType: "application/json",
        data: { id: id },
        success: data => {
            console.log(data);
            $("#exam-title").text(data.exam.title);
            $("#exam-text").text(data.exam.text);
            data.questions.forEach((element, index) => {
                $("#questions").append('<p>' + element.text + '</p>');
            });
            return data.exam;
        },
        error: () => {
            Swal.fire(
                'Hata!',
                'Bir hata oluştu. Lütfen tekrar deneyin.',
                'error'
            );
        }
    });
}

deleteExam = (id) => {
    $.ajax({
        type: "delete",
        url: deleteExamApi + "?id=" + id,
        contentType: "application/json",
        headers: {
            "Authorization": sessionStorage.getItem("token")
        },
        success: data => {
            window.location = "/exam/list"
        },
        error: () => {
            Swal.fire(
                'Hata!',
                'Bir hata oluştu. Lütfen tekrar deneyin.',
                'error'
            );
        }
    });
}