
let userRegister = {
    name: "anya",
    surname: "kramar",
    username: "kramaranya15",
    password: "anya15",
    phoneNumber: "0665503802",
    dateOfBirth: "2022.01.15"
};

let userLogin = {
    username: "kramaranya15",
    password: "anya15"
};

let userUpdate = {
    name: "User2",
    surname: "User",
    username: "user2",
    password: "us2",
    phoneNumber: "93299984",
    dateOfBirth: "2002.05.16"
}

//User

/*$.post("https://localhost:7082/User/Login", userLogin, function( data, status ){
    console.log("Data: " + data + "\nStatus: " + status);
});*/

/*$.post("https://localhost:7082/User/Register", userRegister, function( data, status ){
    console.log("Data: " + data + "\nStatus: " + status);
});*/


/*
$.get('https://localhost:7082/User/Info?username=kramaranya', function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".users").html('<div class="user">\n' +
        `        <p class="name">${data.name}</p>\n` +
        `        <p class="surname">${data.surname}</p>\n` +
        `        <p class="username">${data.username}</p>\n` +
        `        <p class="password">${data.password}</p>\n` +
        `        <p class="dateofbirth">${data.dateOfBirth}</p>\n` +
        `        <p class="phonenumber">${data.phoneNumber}</p>\n` +
        '    </div>')
});
*/

/*$.get("https://localhost:7082/User", function (data, status){
    
    console.log("Data: " + data + "\nStatus: " + status);
    $(".users").html(data.map((user) => '<div class="user">\n' +
        `         <p class="name">${user.name}</p>\n` +
        `        <p class="surname">${user.surname}</p>\n` +
        `        <p class="username">${user.username}</p>\n` +
        `        <p class="password">${user.password}</p>\n` +
        `        <p class="dateofbirth">${user.dateOfBirth}</p>\n` +
        `        <p class="phonenumber">${user.phoneNumber}</p>\n` +
        '    </div>'))
})*/

/*$.get("https://localhost:7082/User/Books?id=22", function(data, status){
    console.log("Data: " + data + "\nStatus: " + status);
});*/

/*$.ajax({
  url: 'https://localhost:7082/User/Update',
  type: 'PUT',
  success: function(data, response) {
      console.log("Data: " + data + "\nStatus: " + response)
  },
    data: userUpdate
});*/

/*$.ajax({
  url: 'https://localhost:7082/User/Book?userId=5&bookId=11',
  type: 'PUT',
  success: function(response) {
    console.log("Status: " + response)
  }
});*/

/*$.ajax({
  url: 'https://localhost:7082/User/Delete?id=18',
  type: 'DELETE',
  success: function(status) {
    console.log("Status: " + status)
  }
});*/

/*$.ajax({
  url: 'https://localhost:7082/User/Book/Delete?userId=22&bookId=11',
  type: 'DELETE',
  success: function(status) {
    console.log("Status: " + status)
  }
});*/


//Book

/*$.get("https://localhost:7082/Book", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Book/Genre?id=1", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Book/Author?id=1", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Book/Id?id=3", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Book/Name?name=on", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/



//Genre

/*$.get("https://localhost:7082/Genre", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Genre/Id?id=4", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Genre/Name?name=ry", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/



//Author

/*$.get("https://localhost:7082/Author", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*$.get("https://localhost:7082/Author/Id?id=4", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*
$.get("https://localhost:7082/Author/Name?name=oa", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
})*/

/*var getAuthorName = function (id) {
    let result
    $.get(`https://localhost:7082/Author/Id?id=${id}`, function (data){
        /!*Author.name = data.name + ' ' + data.surname;
        console.log(Author.name)
        return Author.name;*!/
        result = data.name + ' ' + data.surname;
    })
    //return Author.name;
    return result;
}*/

function getAuthorName( id )
{
    var result = null;
    var scriptUrl = "https://localhost:7082/Author/Id?id=" + id;
    $.ajax({
        url: scriptUrl,
        type: 'get',
        /*dataType: 'html',*/
        async: false,
        success: function(data) {
            //console.log(data.name)
            result = data.name + ' ' + data.surname;
        }
    });
    return result;
}

function getGenreName( id )
{
    var result = null;
    var scriptUrl = "https://localhost:7082/Genre/Id?id=" + id;
    $.ajax({
        url: scriptUrl,
        type: 'get',
        /*dataType: 'html',*/
        async: false,
        success: function(data) {
            //console.log(data.name)
            result = data.name;
        }
    });
    return result;
}

/*$.get("https://localhost:7082/Book", function (data, status){
    
    console.log("Data: " + data + "\nStatus: " + status);
    $(".books").html(data.map((book) => '<div class="book">\n' +
        `        <p class="title">${book.title}</p>\n` +
        `        <p class="publication date">${book.publicationDate}</p>\n` +
        `        <p class="quantity">${book.quantity}</p>\n` +
        `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
        `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +"--------------"+
        '    </div>'))
})*/
/*
$.get("https://localhost:7082/Author", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".authors").html(data.map((author) => '<div class="author">\n' +
        `        <p class="Author">${author.name} ${author.surname}</p>` +"--------------"+
        '    </div>'))
})

$.get("https://localhost:7082/Genre", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".genres").html(data.map((genre) => '<div class="genre">\n' +
        `        <p class="Genre">${genre.name}</p>` +"--------------"+
        '    </div>'))
})

$.get("https://localhost:7082/Book/Name?name=on", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".books").html(data.map((book) => '<div class="book">\n' +
        `        <p class="title">${book.title}</p>\n` +
        `        <p class="publication date">${book.publicationDate}</p>\n` +
        `        <p class="quantity">${book.quantity}</p>\n` +
        `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
        `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +"--------------"+
        '    </div>'))
})

$.get("https://localhost:7082/Book/Genre?id=1", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".books").html(data.map((book) => '<div class="book">\n' +
        `        <p class="title">${book.title}</p>\n` +
        `        <p class="publication date">${book.publicationDate}</p>\n` +
        `        <p class="quantity">${book.quantity}</p>\n` +
        `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
        `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +"--------------"+
        '    </div>'))
})

$.get("https://localhost:7082/User/Books?id=22", function(data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".books").html(data.map((book) => '<div class="book">\n' +
        `        <p class="title">${book.title}</p>\n` +
        `        <p class="publication date">${book.publicationDate}</p>\n` +
        `        <p class="quantity">${book.quantity}</p>\n` +
        `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
        `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +"--------------"+
        '    </div>'))
});

$.get("https://localhost:7082/Book/Author?id=1", function (data, status){
    console.log("Data: " + data + "\nStatus: " + status);
    $(".books").html(data.map((book) => '<div class="book">\n' +
        `        <p class="title">${book.title}</p>\n` +
        `        <p class="publication date">${book.publicationDate}</p>\n` +
        `        <p class="quantity">${book.quantity}</p>\n` +
        `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
        `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +"--------------"+
        '    </div>'))
})*/

function formsChangeInit() {
    $(".btn-log").click(function () {
        console.log("clicked");
        $(".btn-log").addClass("hidden");
        $(".register-form").addClass("unactive");

        $(".btn-reg").removeClass("hidden");
        $(".login-form").removeClass("unactive");
    });

    $(".btn-reg").click(function () {
        $(".btn-reg").addClass("hidden");
        $(".login-form").addClass("unactive");

        $(".btn-log").removeClass("hidden");
        $(".register-form").removeClass("unactive");
    });
}

var UserData = {};

function onRegisterInit() {
    $("#submit").click(function (e) {
        e.preventDefault();
        if ($("#name").val() != "" && $("#surname").val() != "" && $("#user_name").val() != "" && $("#password").val() != ""
            && ($("#phone_number")).val() != "" && ($("#date_of_birth")).val() != "") 
        {
            $('.manage-buttons-wrapper').removeClass('hidden')
            let new_user = {
                name: $("#name").val(),
                surname: $("#surname").val(),
                userName: $("#user_name").val(),
                password: $("#password").val(),
                phoneNumber: $("#phone_number").val(),
                dateOfBirth: $("#date_of_birth").val()
            };
            console.log(new_user);
            //var result = register(new_user);
            $.post("https://localhost:7082/User/Register", new_user, function (data, status) {
                console.log("Data: " + data + "\nStatus: " + status);
                if (status == "success") {
                    $('.container').addClass('hidden')
                    $('.users').removeClass('hidden')
                    $('.books').removeClass('hidden')
                    
                    UserData.userName = new_user.userName

                    $.get(`https://localhost:7082/User/Info?username=${UserData.userName}`, function(data, status) {
                        console.log("Data: " + data + "\nStatus: " + status);
                        $(".users").html(`<ul class="profile">
        <li class="header">My profile</li>
        <li class="user-name-text">Name: ${data.name}</li>
        <li class="user-surname-text">Surname: ${data.surname}</li></li>
        <li class="user-username-text">Username: ${data.username}</li></li>
        <li class="user-password-text">Password: ${data.password}</li></li>
        <li class="user-phone-number-text">Pnone number: ${data.phoneNumber}</li></li>
        <li class="user-date-of-birth-text">Date of Birth: ${data.dateOfBirth}</li> </li>
    </ul>`
                        );
                    })

                    $.get(`https://localhost:7082/User/Books?username=${UserData.userName}`, function(data, status){
                        console.log("Data: " + data + "\nStatus: " + status);
                        if(data != "This user has no book") {
                            $(".books").html(data.map((book) => '<div class="book">\n' +
                                `        <p class="title">${book.title}</p>\n` +
                                `        <p class="publication-date">${book.publicationDate}</p>\n` +
                                `        <p class="quantity">${book.quantity}</p>\n` +
                                `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
                                `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +
                                `        <button id=${book.id} class="delete-button" onclick="onDeleteInit()">Delete</button>\n` +
                                '    </div>'))
                        } else {
                            $(".books").html('<div class="book">\n' +
                                `        <p class="title">This user has no book</p>`)
                        }
                       
                    });

                   /* $.get(`https://localhost:7082/User/Info?username=${new_user.userName}`, function(data, status){
                        console.log("Data: " + data + "\nStatus: " + status);
                        $(".user").html('<div class="user">\n' +
                            `        <p class="Name">${data.name}</p>\n` +
                            `        <p class="Surname">${data.surname}</p>\n` +
                            `        <p class="Username">${data.userName}</p>\n` +
                            `        <p class="Password">${data.password}</p>\n` +
                            `        <p class="Phone Number">${data.phoneNumber}</p>\n` +
                            `        <p class="Date of Birth">${data.dateOfBirth}</p>\n` +
                            '    </div>')
                    });*/
                }
            });
        } else {
            alert("Fill all the fields!");
        }
    });
}

function onLoginInit() {
    $("#submit_login").click(function (e) {
        e.preventDefault();
        if ($("#user_name_login").val() != "" && $("#password_login").val() != "") {
            let new_user = {
                userName: $("#user_name_login").val(),
                password: $("#password_login").val(),
            };
            $('.manage-buttons-wrapper').removeClass('hidden')
            console.log(new_user);
            /*let status = login(new_user).then();
            console.log(status);*/
            $.post("https://localhost:7082/User/Login", new_user, function (data, status) {
                console.log("Data: " + data + "\nStatus: " + status);
                if (status == "success") {
                    $('.container').addClass('hidden')
                    $('.users').removeClass('hidden')
                    $('.books').removeClass('hidden')
                    UserData.userName = new_user.userName;

                    $.get(`https://localhost:7082/User/Info?username=${UserData.userName}`, function(data, status) {
                        console.log("Data: " + data + "\nStatus: " + status);
                        $(".users").html(`<ul class="profile">
        <li class="header">My profile</li>
        <li class="user-name-text">Name: ${data.name}</li>
        <li class="user-surname-text">Surname: ${data.surname}</li></li>
        <li class="user-username-text">Username: ${data.username}</li></li>
        <li class="user-password-text">Password: ${data.password}</li></li>
        <li class="user-phone-number-text">Pnone number: ${data.phoneNumber}</li></li>
        <li class="user-date-of-birth-text">Date of Birth: ${data.dateOfBirth}</li> </li>
    </ul>`
                        );
                    })

                    $.get(`https://localhost:7082/User/Books?username=${UserData.userName}`, function(data, status){
                        console.log("Data: " + data + "\nStatus: " + status);
                        if(data != "This user has no book") {
                            $(".books").html(data.map((book) => '<div class="book">\n' +
                                `        <p class="title">Title: ${book.title}</p>\n` +
                                `        <p class="publication-date">Publication Date: ${book.publicationDate}</p>\n` +
                                `        <p class="quantity">Quantity: ${book.quantity}</p>\n` +
                                `        <p class="author">Author: ${getAuthorName(book.authorId)}</p>\n` +
                                `        <p class="genre">Genre: ${getGenreName(book.genreId)}</p>\n` +
                                `        <button id=${book.id} class="delete-button" onclick="onDeleteInit()">Delete</button>\n` +
                                '    </div>'))
                        } else {
                            $(".books").html('<div class="book">\n' +
                                `        <p class="title">This user has no book</p>`)
                        }

                    });
                }
            });
            //location.replace('../wwwroot/accountsMenu.html')
        } else {
            alert("Fill all the fields!");
        }
    });
}

function onLogoutInit(){
    $("#logout").click(function () {
        location.reload();
    });
}

function onBookInit(){
    $("#books-button").click(function (e) {
        e.preventDefault();
        $('.container').addClass('hidden')
        $('.users').addClass('hidden')
        $('.books').addClass('hidden')
        $('.books-button').removeClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').addClass('hidden')
        $('.books-authors').addClass('hidden')
        
        $.get("https://localhost:7082/Book", function (data, status){

            console.log("Data: " + data + "\nStatus: " + status);
            $(".books-button").html(data.map((book) => '<div class="book">\n' +
                `        <p class="title">Title: ${book.title}</p>\n` +
                `        <p class="publication-date">Publication Date: ${book.publicationDate}</p>\n` +
                `        <p class="quantity">Quantity: ${book.quantity}</p>\n` +
                `        <p class="author">Author: ${getAuthorName(book.authorId)}</p>\n` +
                `        <p class="genre">Genre: ${getGenreName(book.genreId)}</p>\n` +
                `        <button id=${book.id} class="add-button" onclick="onAddInit()">Add</button>\n` +
                '    </div>'))
        })
    });
}


function onGenreInit(){
    $("#genres-button").click(function (e) {
        e.preventDefault();
        $('.container').addClass('hidden')
        $('.users').addClass('hidden')
        $('.books').addClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').removeClass('hidden')
        $('.books-authors').addClass('hidden')
        $.get("https://localhost:7082/Genre", function (data, status){

            console.log("Data: " + data + "\nStatus: " + status);
            $(".genres-button").html(data.map((genre) => '<div class="genre">\n' +
                `        <p class="Genre">${genre.name}</p>` +
                `        <button id=${genre.id} class="genre-book-button" onclick="onGenreBookInit()">Find books</button>\n` +
                '    </div>'))
        })
    });
}

function onAuthorInit(){
    $("#authors-button").click(function (e) {
        e.preventDefault();
        $('.container').addClass('hidden')
        $('.users').addClass('hidden')
        $('.books').addClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').removeClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').addClass('hidden')
        $('.books-authors').addClass('hidden')
        $.get("https://localhost:7082/Author", function (data, status){

            console.log("Data: " + data + "\nStatus: " + status);
            $(".authors-button").html(data.map((author) => '<div class="author">\n' +
                `        <p class="Author">${author.name} ${author.surname}</p>` +
                `        <button id=${author.id} class="author-book-button" onclick="onAuthorBookInit()">Find books</button>\n` +
                '    </div>'))
        })
    });
}

function onProfileInit(){
    $("#my-profile-button").click(function (e) {
        e.preventDefault();
        $('.container').addClass('hidden')
        $('.users').removeClass('hidden')
        $('.books').removeClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').addClass('hidden')
        $('.books-authors').addClass('hidden')

        $.get(`https://localhost:7082/User/Info?username=${UserData.userName}`, function(data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
            $(".users-button").html(`<ul class="profile">
        <li class="header">My profile</li>
        <li class="user-name-text">Name: ${data.name}</li>
        <li class="user-surname-text">Surname: ${data.surname}</li></li>
        <li class="user-username-text">Username: ${data.username}</li></li>
        <li class="user-password-text">Password: ${data.password}</li></li>
        <li class="user-phone-number-text">Pnone number: ${data.phoneNumber}</li></li>
        <li class="user-date-of-birth-text">Date of Birth: ${data.dateOfBirth}</li> </li>
    </ul>`
            );
        })

        $.get(`https://localhost:7082/User/Books?username=${UserData.userName}`, function(data, status){
            console.log("Data: " + data + "\nStatus: " + status);
            if(data != "This user has no book") {
                $(".books-button").html(data.map((book) => '<div class="book">\n' +
                    `        <p class="title">Title: ${book.title}</p>\n` +
                    `        <p class="publication-date">Publication Date: ${book.publicationDate}</p>\n` +
                    `        <p class="quantity">Quantity: ${book.quantity}</p>\n` +
                    `        <p class="author">Author: ${getAuthorName(book.authorId)}</p>\n` +
                    `        <p class="genre">Genre: ${getGenreName(book.genreId)}</p>\n` +
                    '    </div>'))
            } else {
                $(".books-button").html('<div class="book">\n' +
                    `        <p class="title">This user has no book</p>`)
            }

        });
    });
}

function onDeleteInit(){
    $(".delete-button").click(function () {
        let deleteBookId = $(this).attr('id');
        let deleteUserName = UserData.userName;

        /*let accountDelete = {
            //userName: deleteUserName,
            userName: UserData.userName,
            accountName: deleteAccountName
        }*/
        $.ajax({
            url: `https://localhost:7082/User/Book/?username=${deleteUserName}&bookId=${deleteBookId}`,
            type: 'DELETE',
            success: function() {
                
                //UserData.userName = new_user.userName;

                $.get(`https://localhost:7082/User/Info?username=${UserData.userName}`, function(data, status) {
                    console.log("Data: " + data + "\nStatus: " + status);
                    $(".users").html(`<ul class="profile">
        <li class="header">My profile</li>
        <li class="user-name-text">Name: ${data.name}</li>
        <li class="user-surname-text">Surname: ${data.surname}</li></li>
        <li class="user-username-text">Username: ${data.username}</li></li>
        <li class="user-password-text">Password: ${data.password}</li></li>
        <li class="user-phone-number-text">Pnone number: ${data.phoneNumber}</li></li>
        <li class="user-date-of-birth-text">Date of Birth: ${data.dateOfBirth}</li> </li>
    </ul>`
                    );
                })

                $.get(`https://localhost:7082/User/Books?username=${UserData.userName}`, function(data, status){
                    console.log("Data: " + data + "\nStatus: " + status);
                    if(data != "This user has no book") {
                        $(".books").html(data.map((book) => '<div class="book">\n' +
                            `        <p class="title">Title: ${book.title}</p>\n` +
                            `        <p class="publication-date">Publication Date: ${book.publicationDate}</p>\n` +
                            `        <p class="quantity">Quantity: ${book.quantity}</p>\n` +
                            `        <p class="author">Author: ${getAuthorName(book.authorId)}</p>\n` +
                            `        <p class="genre">Genre: ${getGenreName(book.genreId)}</p>\n` +
                            `        <button id=${book.id} class="delete-button" onclick="onDeleteInit()">Delete</button>\n` +
                            '    </div>'))
                    } else {
                        $(".books").html('<div class="book">\n' +
                            `        <p class="title">This user has no book</p>`)
                    }

                });
            },
        });

        /*$.ajax({
            url: 'https://localhost:7110/Account',
            type: 'DELETE',
            success: function() {
                $.get(`https://localhost:7110/Account?userName=${deleteUserName}`, function(data){
                    console.log(data);
                    $(".account-list").html(data.map((account) => '<div class="account">\n' +
                        `        <p class="account-name">${account.name}</p>\n` +
                        `        <p class="account-balance">balance:<span>${account.balance}</span></p>\n` +
                        `        <button class="choose-button">Choose</button>\n` +
                        `        <button id=${account.userName} class="delete-button" onclick="onDeleteInit()">Delete</button>\n` +
                        '    </div>'))
                });
            },
            data: accountDelete
        });*/

    });
}

function onAddInit(){
    $(".add-button").click(function () {
        let addBookId = $(this).attr('id');
        let addUserName = UserData.userName;

        $('.container').addClass('hidden')
        $('.users').removeClass('hidden')
        $('.books').removeClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').addClass('hidden')
        $('.books-authors').addClass('hidden')

            $.ajax({
                url: `https://localhost:7082/User/Book?username=${addUserName}&bookId=${addBookId}`,
                type: 'PUT',
                success: function() {
                    $.get(`https://localhost:7082/User/Info?username=${UserData.userName}`, function(data, status) {
                        console.log("Data: " + data + "\nStatus: " + status);
                        $(".users").html(`<ul class="profile">
        <li class="header">My profile</li>
        <li class="user-name-text">Name: ${data.name}</li>
        <li class="user-surname-text">Surname: ${data.surname}</li></li>
        <li class="user-username-text">Username: ${data.username}</li></li>
        <li class="user-password-text">Password: ${data.password}</li></li>
        <li class="user-phone-number-text">Pnone number: ${data.phoneNumber}</li></li>
        <li class="user-date-of-birth-text">Date of Birth: ${data.dateOfBirth}</li> </li>
    </ul>`
                        );
                    })

                    $.get(`https://localhost:7082/User/Books?username=${UserData.userName}`, function(data, status){
                        console.log("Data: " + data + "\nStatus: " + status);
                        if(data != "This user has no book") {
                            $(".books").html(data.map((book) => '<div class="book">\n' +
                                `        <p class="title">Title: ${book.title}</p>\n` +
                                `        <p class="publication-date">Publication Date: ${book.publicationDate}</p>\n` +
                                `        <p class="quantity">Quantity: ${book.quantity}</p>\n` +
                                `        <p class="author">Author: ${getAuthorName(book.authorId)}</p>\n` +
                                `        <p class="genre">Genre: ${getGenreName(book.genreId)}</p>\n` +
                                `        <button id=${book.id} class="delete-button" onclick="onDeleteInit()">Delete</button>\n` +
                                '    </div>'))
                        } else {
                            $(".books").html('<div class="book">\n' +
                                `        <p class="title">This user has no book</p>`)
                        }
                    });
                }
            });
    });
}


function onGenreBookInit(){
    $(".genre-book-button").click(function (e) {
        let genreBookId = $(this).attr('id');
        
        $('.container').addClass('hidden')
        $('.users').addClass('hidden')
        $('.books').addClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').removeClass('hidden')
        $('.books-authors').addClass('hidden')
        
        $.get(`https://localhost:7082/Book/Genre?id=${genreBookId}`, function (data, status){
            $(".books-genres").html(data.map((book) => '<div class="book">\n' +
                `        <p class="title">${book.title}</p>\n` +
                `        <p class="publication-date">${book.publicationDate}</p>\n` +
                `        <p class="quantity">${book.quantity}</p>\n` +
                `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
                `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +
                `        <button id=${book.id} class="add-button" onclick="onAddInit()">Add</button>\n` +
                '    </div>'))
        })
    });
}

function onAuthorBookInit(){
    $(".author-book-button").click(function (e) {
        let authorBookId = $(this).attr('id');

        $('.container').addClass('hidden')
        $('.users').addClass('hidden')
        $('.books').addClass('hidden')
        $('.books-button').addClass('hidden')
        $('.authors-button').addClass('hidden')
        $('.genres-button').addClass('hidden')
        $('.books-genres').addClass('hidden')
        $('.books-authors').removeClass('hidden')
        
        
        $.get(`https://localhost:7082/Book/Author?id=${authorBookId}`, function (data, status){
            $(".books-authors").html(data.map((book) => '<div class="book">\n' +
                `        <p class="title">${book.title}</p>\n` +
                `        <p class="publication-date">${book.publicationDate}</p>\n` +
                `        <p class="quantity">${book.quantity}</p>\n` +
                `        <p class="author">${getAuthorName(book.authorId)}</p>\n` +
                `        <p class="genre">${getGenreName(book.genreId)}</p>\n` +
                `        <button id=${book.id} class="add-button" onclick="onAddInit()">Add</button>\n` +
                '    </div>'))
        })
    });
}

$(document).ready(function () {
    onRegisterInit(); 
    onLoginInit();
    formsChangeInit();
    onBookInit();
    onGenreInit();
    onAuthorInit();
    onProfileInit();
    onDeleteInit();
    onAddInit();
    onGenreBookInit();
    onLogoutInit();
    onAuthorBookInit();
});
