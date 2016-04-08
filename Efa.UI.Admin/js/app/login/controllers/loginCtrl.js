'use strict';
app.controller('loginCtrl', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    //Loadings
    $scope.loadingLogin = false;

    $scope.message = "";

    $scope.login = function () {
        $scope.loadingLogin = true;
        authService.login($scope.loginData).then(function (response) {
            $location.path('/app/dashboard');
        },
         function (err) {
             $scope.authError = err.error_description;
             $scope.loginData = {
                 userName: "",
                 password: ""
             };
             toastr.error(err.error_description);
         })['finally'](function () {
             $scope.loadingLogin = false;
         });
    };

}]);