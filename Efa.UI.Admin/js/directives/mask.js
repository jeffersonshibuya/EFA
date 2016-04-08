(function () {
    'use strict';

    angular.module('app').directive('uiMask', function () {
        return {
            require: '?ngModel',
            link: function($scope, element, attrs, controller) {
                element.mask(attrs.mask);
            }
        };


    });
}());