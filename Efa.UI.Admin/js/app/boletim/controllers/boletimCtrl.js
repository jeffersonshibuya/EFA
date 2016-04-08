(function () {
    'use strict';

    angular
        .module('app')
        .controller('boletimCtrl', boletimCtrl);

    function boletimCtrl(alunoService, $location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'boletimCtrl';
        vm.alunos = [];        

        activate();

        function activate() {            
            vm.alunos = alunoService.getAlunosList();
            if (vm.alunos.length == 0) {
                toastr.error('Nenhum aluno foi selecionado');
                $location.path("/app/alunos");
            }
        }
    }
})();
