'use strict';

/* Controllers */

angular.module('app')
  .controller('AppCtrl', ['$scope', '$localStorage', '$window', '$filter', '$rootScope', 'authService', '$location', '$modal',
    function ($scope, $localStorage, $window, $filter, $rootScope, authService, $location, $modal) {
        // add 'ie' classes to html
        var isIE = !!navigator.userAgent.match(/MSIE/i);
        isIE && angular.element($window.document.body).addClass('ie');
        isSmartDevice($window) && angular.element($window.document.body).addClass('smart');

        // Configure Toastr
        toastr.options.timeOut = 3000;
        toastr.options.positionClass = 'toast-top-right';

        //Window Back
        $scope.$back = function () {
            window.history.back();
        };

        //Todos
        if (localStorage.getItem('todos') == '[]') {
            $rootScope.remainingTodoCount = 0;
            localStorage.setItem('todos', '[]');
        } else {
            $rootScope.remainingTodoCount = $filter('filter')(JSON.parse(localStorage.getItem('todos') || 0), { completed: false }).length;
        }

        //Account
        $scope.logout = function () {
            authService.logOut();
            $location.path('/access/login');
        };


        if (authService.authentication.userName == undefined) {
            $scope.authentication = {
                nome: "",
                isAdmin: false,
            };
            var user = JSON.parse(localStorage.getItem('user'));
            $scope.authentication.nome = user.data.FullName;
            if (authService.authentication.isAuth) {
                if (user.data.Roles.indexOf('Admin') != -1) {
                    $scope.authentication.isAdmin = true;
                }
            }
        } else {
            $scope.authentication = authService.authentication;
        }

        $scope.alterarSenha = function (size) {
            $scope.modalInstance = $modal.open({
                templateUrl: 'js/app/accounts/views/alterarSenha.html',
                size: size,
                resolve: {
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/accounts/controllers/alterarSenhaCtrl.js', 'js/Repositories/UsuarioRepository.js']);
                        }
                    ]
                },
                controller: 'alterarSenhaCtrl as vm',
            });
            $scope.modalInstance.result.then(function (data) {
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                $scope.modalInstance = undefined;
            });
        };



        //Configure Loading
        $scope.$on('LOAD', function () { $scope.loading = true; });
        $scope.$on('UNLOAD', function () { $scope.loading = false; });

        // config
        $scope.app = {
            name: 'English For All',
            version: 'v. 1.0',
            // for chart colors
            color: {
                primary: '#7266ba',
                info: '#23b7e5',
                success: '#27c24c',
                warning: '#fad733',
                danger: '#f05050',
                light: '#e8eff0',
                dark: '#3a3f51',
                black: '#1c2b36'
            },
            settings: {
                themeID: 1,
                navbarHeaderColor: 'bg-black',
                navbarCollapseColor: 'bg-white-only',
                asideColor: 'bg-black',
                headerFixed: true,
                asideFixed: false,
                asideFolded: false,
                asideDock: false,
                container: false
            }
        }

        // save settings to local storage
        if (angular.isDefined($localStorage.settings)) {
            $scope.app.settings = $localStorage.settings;
        } else {
            $localStorage.settings = $scope.app.settings;
        }
        $scope.$watch('app.settings', function () {
            if ($scope.app.settings.asideDock && $scope.app.settings.asideFixed) {
                // aside dock and fixed must set the header fixed.
                $scope.app.settings.headerFixed = true;
            }
            // save to local storage
            $localStorage.settings = $scope.app.settings;
        }, true);

        // angular translate
        //$scope.lang = { isopen: false };
        //$scope.langs = { en: 'English', de_DE: 'German', it_IT: 'Italian' };
        //$scope.selectLang = $scope.langs[$translate.proposedLanguage()] || "English";
        //$scope.setLang = function (langKey, $event) {
        //    // set the current lang
        //    $scope.selectLang = $scope.langs[langKey];
        //    // You can change the language during runtime
        //    $translate.use(langKey);
        //    $scope.lang.isopen = !$scope.lang.isopen;
        //};

        function isSmartDevice($window) {
            // Adapted from http://www.detectmobilebrowsers.com
            var ua = $window['navigator']['userAgent'] || $window['navigator']['vendor'] || $window['opera'];
            // Checks for iOs, Android, Blackberry, Opera Mini, and Windows mobile devices
            return (/iPhone|iPod|iPad|Silk|Android|BlackBerry|Opera Mini|IEMobile/).test(ua);
        }

    }]);


