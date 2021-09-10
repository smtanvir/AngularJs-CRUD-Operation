angular.module("medicineApp")
    .controller("genericgrCtrl", ($scope, $http, apiUrl, apiService, $location) => {

        $scope.insert = function () {
            $('#createModal').modal('show');
        }
        //for create
        $scope.creategroup = f => {
            console.log(f);
            apiService.post(`${apiUrl}GenericGroups`, $scope.current)
                .then(r => {
                    $scope.model.genericgroups.push(r.data);
                    $scope.current = {};
                    $scope.apiMessage = "Data inserted successfully!!";
                    f.$setPristine();
                    f.$setUntouched();
                }, err => {
                    $scope.apiMessage = "Data insert failed!!";
                });
            $('#createModal').modal('hide');
        }

        //for edit
        $scope.edit = t => {
            angular.copy(t, $scope.current);
            console.log($scope.current);
            $('#editModal').modal('show');
        }
        //for update
        $scope.updateGroup = f => {
            apiService.put(`${apiUrl}GenericGroups/${$scope.current.id}`, $scope.current)
                .then(r => {
                    var i = $scope.model.types.findIndex(t => t.id == $scope.current.id);
                    angular.copy($scope.current, $scope.model.genericgroups[i]);
                    console.log($scope.model.genericgroups[i]);
                    $scope.apiMessage = "Data Updated successfully!!";
                    f.$setPristine();
                    f.$setUntouched();
                }, err => {
                    $scope.apiMessage = "Data update failed!!";
                });
            $('#editModal').modal('hide');
        }

        //for delete

        $scope.delModal = null;
        $scope.confirmDelete = (t) => {
            $scope.delModal = new bootstrap.Modal(document.getElementById('delModal'), {});
            $scope.current = t;
            $scope.delModal.show();
        }
        $scope.cancelDeleteType = () => {
            $scope.current = {};
            $scope.delModal.hide();
        }
        $scope.doDeleteType = () => {
            console.log("del");
            console.log($scope.current);
            apiService.delete(`${apiUrl}GenericGroups/`, $scope.current.id)
                .then(r => {
                    var i = $scope.model.genericgroups.findIndex(t => t.id == $scope.current.id);
                    $scope.model.genericgroups.splice(i, 1);
                    $scope.apiMessage = "Data Deleted!!";
                },
                err => {
                        $scope.apiMessage = "Data delete failed!!";
                    })
                .finally(() => {
                    $scope.delModal.hide();
                })
        }
    })