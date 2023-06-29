$(document).ready(function () {

    viewResults = function () {
        if (!$("#ViewResults").hasClass("active")) {
            $.ajax({
                url: '/api/StudentApi/GetAllStudentsResult',
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (students) {
                        var html = '<table class = "table text-white my-5">';
                        html += '<tr><th>Name</th><th>RollNo</th><th>English</th><th>Hindi</th><th>Science</th><th>Total Marks</th><th>Status</th></tr>';
                        $.each(students, function (i, student) {
                            html += '<tr>';
                            html += '<td>' + student.User.Name + '</td>';
                            html += '<td>' + student.Student.RollNo + '</td>';
                            html += '<td>' + student.Student.English + '</td>';
                            html += '<td>' + student.Student.Hindi + '</td>';
                            html += '<td>' + student.Student.Science + '</td>';
                            html += '<td>' + student.TotalMarks + '</td>';
                            html += '<td>' + student.Result + '</td>';
                            html += '</tr>';
                        });
                        html += '</table>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#ViewResults").addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };


    manageStudents = function () {
        if (!$("#ManageStudents").hasClass("active")) {
            $.ajax({
                url: '/api/StudentApi/GetAllStudents',
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (students) {
                        var html = '<a class="btn btn-sm btn-info m-1" id="add" onclick="createStudentDetail()">Add Student</a>';
                        html += '<table class = "table text-white my-5">';
                        html += '<tr> <th class="col-1">Roll No</th> <th class="col-3">Name</th> <th class="col-3">Total Marks</th> <th class="col-2">Status</th> <th class="col-3"></th> </tr>';
                        $.each(students, function (i, student) {
                            html += '<tr>';
                            html += '<td>' + student.Student.RollNo + '</td>';
                            html += '<td>' + student.User.Name + '</td>';
                            html += '<td>' + student.TotalMarks + '</td>';
                            html += '<td>' + student.Result + '</td>';
                            html += '<td> <a class="btn btn-sm btn-success m-1" id="detail' + student.User.ID + '" onclick="studentDetails(' + student.User.ID + ')">Details</a>';
                            html += '<a class="btn btn-sm btn-primary m-1" id="' + student.User.ID + '">Edit</a>';
                            html += '<a class="btn btn-sm btn-danger m-1" id="delete' + student.User.ID + '"onclick="deleteStudentConfirmation(' + student.User.ID +')">Delete</a> </td>';
                            html += '</tr>';
                        });
                        html += '</table>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#ManageStudents").addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    createStudentDetail = function () {
        
        var html =

        $("#Admin").html(html);
        $(".active").removeClass("active");
        $("#delete" + id).addClass("active");               
            
    };

    studentDetails = function (id) {
        if (!$("#detail" + id).hasClass("active")) {
            $.ajax({
                url: '/api/StudentApi/GetStudentByUserID?id=' + id,
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (student) {
                        var html = '<table class = "table text-white my-5">';
                        html += '<tr> <th>Roll No</th> <td>' + student.Student.RollNo + '</td> </tr>';
                        html += '<tr> <th>Name</th> <td>' + student.User.Name + '</td> </tr>';
                        html += '<tr> <th>Username</th> <td>' + student.User.Username + '</td> </tr>';
                        html += '<tr> <th>English</th> <td>' + student.Student.English + '</td> </tr>';
                        html += '<tr> <th>Hindi</th> <td>' + student.Student.Hindi + '</td> </tr>';
                        html += '<tr> <th>Science</th> <td>' + student.Student.Science + '</td> </tr>';
                        html += '<tr> <th>Total Marks</th> <td>' + student.TotalMarks + '</td> </tr>';
                        html += '<tr> <th>Status</th> <td>' + student.Result + '</td> </tr>';
                        html += '</table>';
                        html += '<a class="btn btn-outline-light rounded-0" onclick="manageStudents()">Back</a>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#detail" + id).addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    deleteStudentConfirmation = function (id) {
        if (!$("#delete" + id).hasClass("active")) {
            $.ajax({
                url: '/api/StudentApi/GetStudentByUserID?id=' + id,
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (student) {
                        var html = '<h4>Are you sure you want to delete student?</h4>';
                        html += '<h5>Roll no. ' + student.Student.RollNo + ' ' + student.User.Name + '</h5>';
                        html += '<a class="btn btn-outline-light rounded-0 mx-1" onclick="deleteStudent(' + id + ')">Delete</a>';
                        html += '<a class="btn btn-outline-light rounded-0 mx-1" onclick="manageStudents()">Cancel</a>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#delete" + id).addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    deleteStudent = function (id) {
        $.ajax({
            url: '/api/UserApi/DeleteUserByID?id=' + id,
            type: 'DELETE',
            contentType: 'application/ json; charset = utf - 8',
            dataType: 'json',
            success:
                function () {
                    
                    manageStudents();
                },
            error:
                function () {

                }
        });
    };


    manageAdmins = function () {
        if (!$("#ManageAdmins").hasClass("active")) {
            $.ajax({
                url: '/api/AdminApi/GetAllAdmins',
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (admins) {
                        var html = '<a class="btn btn-sm btn-info m-1" id="AddAdmin">Add Admin</a>';
                        html += '<table class = "table text-white my-5">';
                        html += '<tr> <th class="col-6">Name</th> <th class="col-3">Age</th> <th class="col-3"></th> </tr>';
                        $.each(admins, function (i, admin) {
                            html += '<tr>';
                            html += '<td>' + admin.User.Name + '</td>';
                            html += '<td>' + admin.Admin.Age + '</td>';
                            html += '<td> <a class="btn btn-sm btn-success m-1" id="detail' + admin.User.ID + '" onclick="adminDetails(' + admin.User.ID + ')">Details</a>';
                            html += '<a class="btn btn-sm btn-primary m-1" id="' + admin.User.ID + '">Edit</a>';
                            html += '<a class="btn btn-sm btn-danger m-1" id="delete' + admin.User.ID + '" onclick="deleteAdminConfirmation(' + admin.User.ID + ')">Delete</a> </td>';
                            html += '</tr>';
                        });
                        html += '</table>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#ManageAdmins").addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    adminDetails = function (id) {
        if (!$("#detail" + id).hasClass("active")) {
            $.ajax({
                url: '/api/AdminApi/GetAdminByUserID?id=' + id,
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (admin) {
                        var html = '<table class = "table text-white my-5">';
                        html += '<tr> <th>Name</th> <td>' + admin.User.Name + '</td> </tr>';
                        html += '<tr> <th>Username</th> <td>' + admin.User.Username + '</td> </tr>';
                        html += '<tr> <th>Age</th> <td>' + admin.Admin.Age + '</td> </tr>';
                        html += '</table>';
                        html += '<a class="btn btn-outline-light rounded-0" onclick="manageAdmins()">Back</a>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#detail" + id).addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    deletAdminConfirmation = function (id) {
        if (!$("#delete" + id).hasClass("active")) {
            $.ajax({
                url: '/api/AdminApi/GetAdminByUserID?id=' + id,
                type: 'GET',
                contentType: 'application/ json; charset = utf - 8',
                dataType: 'json',
                success:
                    function (admin) {
                        var html = '<h4>Are you sure you want to delete admin?</h4>';
                        html += '<h5>' + admin.User.Name + " of age " + admin.Admin.Age + '</h5>';
                        html += '<a class="btn btn-outline-light rounded-0 mx-1" onclick="deleteAdmin(' + id + ')">Delete</a>';
                        html += '<a class="btn btn-outline-light rounded-0 mx-1" onclick="manageAdmins()">Cancel</a>';

                        $("#Admin").html(html);
                        $(".active").removeClass("active");
                        $("#delete" + id).addClass("active");
                    },
                error:
                    function () {

                    }
            });
        };
    };

    deleteAdmin = function (id) {
        $.ajax({
            url: '/api/UserApi/DeleteUserByID?id=' + id,
            type: 'DELETE',
            contentType: 'application/ json; charset = utf - 8',
            dataType: 'json',
            success:
                function () {

                    manageAdmins();
                },
            error:
                function () {

                }
        });
    };
});