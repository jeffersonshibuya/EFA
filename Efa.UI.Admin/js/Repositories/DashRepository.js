(function () {
    'use strict';

    angular
        .module('app')
        .factory('DashRepository', DashRepository);

    DashRepository.$inject = ['$http', 'cache', 'API_URL'];


    function DashRepository($http, cache, API_URL) {

        var service = {
            dash: dash,
        };

        return service;

        function dash() {
            var myCache = cache.get('cacheDash');
            return $http.get(API_URL+'api/dash', {cache: myCache});
        }
    };


     
})();