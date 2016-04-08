(function () {
    'use strict';

    angular.module('app').controller('notasCtrl', notasCtrl);

    function notasCtrl(NotasRepository, $cookieStore, $location, modalService, alunoService, cache) {
        var vm = this;
        vm.aluno = {};
        vm.notas = {};
        vm.cadastro = true;       

        vm.aluno = alunoService.getAluno();       

        activate();

        function activate() {
            if (vm.aluno.Nome != null) {
                if (vm.aluno.NotasId != null) {                    
                    NotasRepository.getAlunoNotas(vm.aluno.NotasId).then(function(result) {
                            if (result.data != null) {
                                vm.cadastro = false;
                                vm.notas = result.data;
                            }
                        },
                        function(error) {
                            toastr.error(error);
                        });
                }
            } else {
                toastr.error("Por favor selecione um aluno");
                $location.path("/app/alunos");
            }

        }

        //Definindo total notas
        if (vm.aluno.Turma.TipoProva == 'Default' || vm.aluno.Turma.TipoProva == undefined) {
            vm.totalQuiz = 25;
            vm.totalWritten = 50;
        } else {
            vm.totalQuiz = 50;
            vm.totalWritten = 100;
        }

        vm.add = function (notas) {
            //Arrendondamento das médias
            notas.MediaGeral = Math.ceil(vm.notas.MediaGeral);
            notas.MediaWrittenTest = Math.ceil(vm.notas.MediaWrittenTest);
            notas.MediaQuiz = Math.ceil(vm.notas.MediaQuiz);
            notas.MediaOralTest = Math.ceil(vm.notas.MediaOralTest);

            NotasRepository.addNotas(vm.aluno.AlunoId, notas).success(function (data) {
                toastr.success('Notas cadastradas com sucesso');
                cache.remove('cacheAlunos');
                window.history.back();
                //$location.path("/app/alunos");
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

        vm.save = function (notas) {
            //Arrendondamento das médias
            notas.MediaGeral = Math.ceil(vm.notas.MediaGeral);
            notas.MediaWrittenTest = Math.ceil(vm.notas.MediaWrittenTest);
            notas.MediaQuiz = Math.ceil(vm.notas.MediaQuiz);
            notas.MediaOralTest = Math.ceil(vm.notas.MediaOralTest);

            NotasRepository.savenotas(notas).success(function (data) {
                toastr.success('Notas salvas com sucesso');
                cache.remove('cacheAlunos');
                window.history.back();
                //$location.path("/app/alunos");
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

        vm.delete = function (notas) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Excluir',
                headerText: 'Excluir Notas',
                bodyText: 'Tem certeza que deseja exlcuir essas notas?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                var notasId = notas.NotasId;
                NotasRepository.deleteNotas(notasId, vm.aluno.AlunoId).then(function () {
                    cache.remove('cacheAlunos');
                    toastr.success("Notas excluídas com Sucesso!");
                    $location.path("/app/alunos");
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir notas!");
                };
            });
        };

    }
})();
