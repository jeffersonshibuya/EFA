(function () {
    'use strict';

    angular.module('app').controller('contatosCtrl', contatosCtrl);

    function contatosCtrl($scope, $http, $filter, ContatoGrupoRepository, ContatoPessoaRepository, modalService, cache) {
        var vm = this;
        vm.grupos = [];
        vm.contatos = [];
        vm.contatos = {};

        $scope.filter = '';

        activate();

        function activate() {
            $scope.item = '';
            //Get Grupos
            ContatoGrupoRepository.getGrupos().then(function (result) {
                vm.grupos = result.data;
            });
            ContatoPessoaRepository.getContatos().then(function (result) {
                vm.contatos = result.data;
                $scope.item = $filter('orderBy')(vm.contatos, 'Nome')[0];
                if ($scope.item) $scope.item.selected = true;
            });
        }

        function guid() {
            function s4() {
                return Math.floor((1 + Math.random()) * 0x10000)
                  .toString(16)
                  .substring(1);
            }
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
              s4() + '-' + s4() + s4() + s4();
        }

        $scope.cancelEdit = function (item) {
            item.editing = false;
            if (item.Status == 'create') {
                $scope.item = $filter('orderBy')(vm.contatos, 'Nome')[0];
                if ($scope.item) $scope.item.selected = true;
            } else {
                $scope.item.selected = true;
            }

        };

        $scope.createGroup = function () {
            var group = { ContatoGrupoId: guid(), Nome: 'Novo Grupo', Status: 'create' };
            group.Nome = $scope.checkItem(group, vm.grupos, 'Nome');
            vm.grupos.unshift(group);
        };

        $scope.cancelEditing = function (item) {
            item.Nome = 'Novo Grupo';
            item.Status = 'create';
        };

        $scope.checkItem = function (obj, arr, key) {
            var i = 0;
            angular.forEach(arr, function (item) {
                if (item[key].indexOf(obj[key]) == 0) {
                    var j = item[key].replace(obj[key], '').trim();
                    if (j) {
                        i = Math.max(i, parseInt(j) + 1);
                    } else {
                        i = 1;
                    }
                }
            });
            return obj[key] + (i ? ' ' + i : '');
        };

        $scope.deleteGroup = function (item) {
            if (item.Nome == 'Novo Grupo') {
                vm.grupos.splice(vm.grupos.indexOf(item), 1);
            } else {
                var modalOptions = {
                    closeButtonText: 'Cancelar',
                    actionButtonText: 'Excluir',
                    headerText: 'Excluir ' + item.Nome + '?',
                    bodyText: 'Todos os contatos do grupo serão excluídos juntos, Deseja continuar?',
                };

                modalService.showModal({}, modalOptions).then(function () {
                    ContatoGrupoRepository.deleteGrupo(item.ContatoGrupoId).then(function () {
                        toastr.success("Grupo excluído com Sucesso!");
                        $.each(vm.grupos, function (i) {
                            if (vm.grupos[i].ContatoGrupoId === item.ContatoGrupoId) {
                                vm.grupos.splice(i, 1);
                                return false;
                            }
                        });
                        activate();
                    }), function (data) {
                        toastr.error(data.message, "Erro ao excluir grupo!");
                    };
                });
            }

        };

        $scope.selectGroup = function (item) {
            if (item.ContatoGrupoId == undefined) {
                $scope.filter = '';
            } else {
                if (item.Nome == 'Novo Grupo') {
                    $scope.filter = 'Novo Grupo';
                } else {
                    $scope.filter = item.ContatoGrupoId;
                }
            }


            angular.forEach(vm.grupos, function (item) {
                item.selected = false;
            });
            $scope.group = item;
            $scope.group.selected = true;
        };

        $scope.doneGroupEditing = function (item) {
            item.editing = false;
            if (item.Status == 'create') {
                ContatoGrupoRepository.addGrupo(item).then(function () {
                    toastr.success("Grupo criado com Sucesso!");
                }), function (data) {
                    toastr.error(data.message, "Erro ao criar grupo!");
                };
            } else {
                ContatoGrupoRepository.saveGrupo(item).then(function () {
                    toastr.success("Grupo salvo com Sucesso!");
                }), function (data) {
                    toastr.error(data.message, "Erro ao salvar grupo!");
                };
            }

        };

        $scope.selectItem = function (item) {
            angular.forEach(vm.contatos, function (item) {
                item.selected = false;
                item.editing = false;
            });
            $scope.item = item;
            $scope.item.selected = true;
        };

        //Function que percorre um array e retorna o index desejado
        function arrayObjectIndexOf(myArray, searchTerm, property) {
            for (var i = 0, len = myArray.length; i < len; i++) {
                if (myArray[i][property] === searchTerm) return i;
            }
            return -1;
        }

        $scope.createContact = function () {
            var item = {
                ContatoGrupoId: $scope.group.ContatoGrupoId,
                Status: 'create'
            };
            $scope.selectItem(item);
            $scope.item.editing = true;
            $scope.item.editingCreate = true;
        };


        $scope.editItem = function (item) {
            if (item && item.selected) {
                item.editing = true;
                item.grupoSelected = vm.grupos[arrayObjectIndexOf(vm.grupos, item.ContatoGrupo.Nome, "Nome")];
            }
        };

        $scope.editItemGroup = function (item) {
            if (item && item.selected) {
                item.editing = true;
                item.grupoSelected = vm.grupos[arrayObjectIndexOf(vm.grupos, item.ContatoGrupo, "Nome")];
            }
        };

        $scope.deleteContact = function (item) {
            if (item.Status == 'create') {
                vm.contatos.splice(vm.contatos.indexOf(item), 1);
                $scope.item = $filter('orderBy')(vm.contatos, 'Nome')[0];
                if ($scope.item) $scope.item.selected = true;
            } else {
                var modalOptions = {
                    closeButtonText: 'Cancelar',
                    actionButtonText: 'Excluir',
                    headerText: 'Excluir ' + item.Nome + '?',
                    bodyText: 'Confirmar exclusão do contato?',
                };

                modalService.showModal({}, modalOptions).then(function () {
                    ContatoPessoaRepository.deleteContato(item.ContatoPessoaId).then(function () {
                        toastr.success("Contato excluído com Sucesso!");
                        cache.remove('cacheDash');
                        vm.contatos.splice(vm.contatos.indexOf(item), 1);
                        $scope.item = $filter('orderBy')(vm.contatos, 'Nome')[0];
                        if ($scope.item) $scope.item.selected = true;

                    }), function (data) {
                        toastr.error(data.message, "Erro ao excluir contato!");
                    };
                });
            }
        };

        $scope.doneContactEditing = function (item) {

            item.editing = false;

            if (item.Status == 'create') {
                ContatoPessoaRepository.addContato(item).then(function (result) {
                    vm.contatos.push(result.data);
                    toastr.success("Contato criado com Sucesso!");
                    cache.remove('cacheDash');
                    activate();
                    if ($scope.item) $scope.item.selected = true;
                }), function (data) {
                    toastr.error(data.message, "Erro ao criar contato!");
                };
            } else {
                item.ContatoGrupo = item.grupoSelected;
                item.ContatoGrupoId = item.grupoSelected.ContatoGrupoId;
                ContatoPessoaRepository.saveContato(item).then(function () {
                    toastr.success("Contato salvo com Sucesso!");
                }), function (data) {
                    toastr.error(data.message, "Erro ao salvar contato!");
                };
            }

        };


    }
})();