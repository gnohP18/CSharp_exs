(function () {
    const api = new ApiInstance();

    $('#login_Form').submit(function (e) {
        e.preventDefault();
        const username = $('#login_Form input[name="username"]').val();
        const password = $('#login_Form input[name="password"]').val();
        console.log($('#login_Form input[name="username"]').val());
        console.log($('#login_Form input[name="password"]').val());
        api.post("api/auth/login", { username, password })
            .then(res => {
                console.log(res);
                window.location.href = "admin/index.html";
            })
    })

    $('#reLogin').on('click', function () {
        const refreshToken = "123";
        api.post("api/auth/refresh", { refreshToken })
            .then(res => {
                console.log(res);
            })
    })
})();