(function () {
    'use strict';

    angular.module('app').controller('dashCtrl', dashCtrl);


    function dashCtrl(DashRepository, $scope, $filter, cache, $rootScope, authService, $location) {
        var vm = this;
        vm.title = 'dashCtrl';

        $scope.percentDone = 0;
        $scope.percentRemain = 100;

        //Todos
        $scope.todos = JSON.parse(localStorage.getItem('todos') || '[]');
        if ($scope.todos.length != 0 && $scope.todos != undefined) {
            $scope.todosDone = $filter('filter')(JSON.parse(localStorage.getItem('todos') || 0), { completed: true });
            $scope.todosRemain = $filter('filter')(JSON.parse(localStorage.getItem('todos') || 0), { completed: false });

            $scope.percentDone = (100 * $scope.todosDone.length) / $scope.todos.length;
            $scope.percentRemain = (100 * $scope.todosRemain.length) / $scope.todos.length;
        }

        activate();

        function activate() {
            $scope.$emit('LOAD');
 
            if (!cache.get('cacheDash')) {
                DashRepository.dash().then(function (result) {
                    cache.put('cacheDash', result.data);
                    vm.dash = cache.get('cacheDash');
                }, function(data) {
                    vm.dash = undefined;
                    $location.path('/access/login');
                    console.log(data.message, "Erro ao buscar dados da dash");
                });
            } else {
                vm.dash = cache.get('cacheDash');
            }

            $scope.$emit('UNLOAD');           
        }        
        
        
    }
})();
