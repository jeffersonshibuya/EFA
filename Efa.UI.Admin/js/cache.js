angular.module('app').
    factory('cache', function($cacheFactory) {
        return $cacheFactory('myCaches');
    });