(function () {
    'use strict';

    angular
        .module('app')
        .controller('createProfessorCtrl', createProfessorCtrl);    

    function createProfessorCtrl(ProfessorRepository, $scope, $modalInstance) {
        var vm = this;
        vm.title = 'createProfessorCtrl';

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };


        vm.cadastrar = function (professor) {
            ProfessorRepository.addProfessor(professor).success(function (data) {
                toastr.success(data.Nome+" Foi cadastrado com sucesso!");
                $modalInstance.close(data);
            }).error(function (error) {
                var errors = [];
                for (var key in error.ModelState) {
                    for (var i = 0; i < error.ModelState[key].length; i++) {
                        errors.push(error.ModelState[key][i]);
                        toastr.error(error.ModelState[key][i]);
                    }
                }
                vm.errors = errors;
            });

        };
    }
})();
