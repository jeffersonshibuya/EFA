'use strict';
app.factory('authService', ['$http', '$q', 'cache', '$rootScope', 'API_URL', function ($http, $q, cache, $rootScope, API_URL) {

    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        nome: "",
        userName: "",
        isAdmin: false
    };

    var _user = {};

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(API_URL + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(API_URL + 'security/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            //localStorage.setItem('authorizationData', JSON.stringify(response));
            localStorage.setItem('authorizationData', response.access_token);

            $http.get(API_URL + 'api/accounts/user/' + loginData.userName).then(function (user) {
                localStorage.setItem('user', JSON.stringify(user));
                var usr = user.data;
                if (usr.Roles.indexOf('Admin') != -1) {
                    _authentication.isAdmin = true;
                }
                _authentication.nome = usr.FullName;
            });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorage.removeItem('authorizationData');
        localStorage.removeItem('user');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.isAdmin = false;

        cache.removeAll();
    };

    var _fillAuthData = function () {

        var authData = localStorage.getItem('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    };

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.user = _user;

    return authServiceFactory;
}]);