$(document).ready(function () {
    var viewResult = $("#ViewResult");
    viewResult.click(function () {
        
        if (!viewResult.hasClass("active")) {

            $.ajax({
                url: '/Base/GetSessionUser',
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (user) {
                        console.log(user);
                        $.ajax({
                            url: '/api/StudentApi/GetAllStudentByUserID?id=' + user.ID,
                            type: 'GET',
                            contentType: 'application/ json; charset = utf - 8',
                            dataType: 'json',
                            success:
                                function (student) {
                                    var html = '<table class = "table text-white my-5">';
                                    html += '<tr><th>Name</th><th>RollNo</th><th>English</th><th>Hindi</th><th>Science</th><th>Total Marks</th><th>Status</th></tr>';
                                    html += '<tr>';
                                    html += '<td>' + student.User.Name + '</td>';
                                    html += '<td>' + student.Student.RollNo + '</td>';
                                    html += '<td>' + student.Student.English + '</td>';
                                    html += '<td>' + student.Student.Hindi + '</td>';
                                    html += '<td>' + student.Student.Science + '</td>';
                                    html += '<td>' + student.TotalMarks + '</td>';
                                    html += '<td>' + student.Result + '</td>';
                                    html += '</tr>';
                                    html += '</table>'
                                    $("#StudentResult").append(html);

                                    viewResult.addClass("active");
                                },
                            error:
                                function () {

                                }
                        })

                    },
                error:
                    function () {

                    }
            })
        }
    })
})