(function() {
    'use strict';

    angular.module('app').directive('confirmationNeeded', confirmationNeeded);

    confirmationNeeded.$inject = [];
    
    function confirmationNeeded() {
        var directive = {
            priority: 1,
            terminal: true,
            link: link
        };
        return directive;

        function link(scope, element, attr) {
            var msg = attr.confirmationNeeded || "Realmente deseja excluir?";
            var clickAction = attr.ngClick;
            element.bind('click', function () {
                if (window.confirm(msg)) {
                    scope.$eval(clickAction);
                }
            });
        }
    }

})();