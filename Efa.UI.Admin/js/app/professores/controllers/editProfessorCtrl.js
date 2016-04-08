(function () {
    'use strict';

    angular
        .module('app')
        .controller('editProfessorCtrl', editProfessorCtrl);

    function editProfessorCtrl(ProfessorRepository, $scope, $modalInstance, professorEdit) {
        var vm = this;

        vm.title = 'Editar Professor';
        
        $scope.professor = professorEdit;

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.save = function (professor) {
            ProfessorRepository.saveProfessor(professor).success(function (data) {
                toastr.info(data.Nome + " Foi salvo com sucesso!");
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

