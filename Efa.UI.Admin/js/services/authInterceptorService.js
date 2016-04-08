﻿'use strict';
angular.module('app')
    .factory('authInterceptorService', ['$q', '$location', '$injector', function ($q, $location, $injector) {

    var authInterceptorServiceFactory = {};

    var _request = function(config) {

        config.headers = config.headers || {};

        //var authData = JSON.parse(localStorage.getItem('authorizationData'));
        var authData = localStorage.getItem('authorizationData');

        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData;
        } 

        return config;
    };

    var _responseError = function(rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('authService');
            authService.logOut();
            $location.path('/access/login');
        }
        return $q.reject(rejection);
    };

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);