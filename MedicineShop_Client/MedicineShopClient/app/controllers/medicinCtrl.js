angular.module("medicineApp")
    .controller("medicineCtrl", ($scope, $http, apiUrl, apiService, $location) => {

        $scope.isEdit = false;
        $scope.getHead = function () {
            return $scope.isEdit ? 'Update Product' : 'Add New Product';
        };
        $scope.insert = function() {
            $('#mcModal').modal('show');
        }

        //for create
        $scope.createMedicines = f => {
            console.log(f);
            apiService.post(`${apiUrl}Medicines`, $scope.current)
                .then(res => {
                    $scope.model.medicines.push(res.data);
                    $scope.current = {};
                    
                    $scope.apiMessage = "Data inserted successfully!!";
                    f.$setPristine();
                    f.$setUntouched();
                }, error => {
                    $scope.apiMessage = "Data insert failed!!";
                });
            $('#mcModal').modal('hide');
        }
        //for edit
        $scope.edit = mc => {
            angular.copy(mc, $scope.current);
            isEdit = true;
            console.log($scope.current);
            $location.path("/editMedicines/:" + mc.id);
        }
        //for update
        $scope.update = f => {
            apiService.put(`${apiUrl}Medicines/${$scope.current.id}`, $scope.current)
                .then(res => {
                    var i = $scope.model.medicines.findIndex(mc => mc.id == $scope.current.id);
                    angular.copy($scope.current, $scope.model.medicines[i]);
                    console.log($scope.model.medicines[i]);
                    $scope.apiMessage = "Data Updated successfully!!";
                    f.$setPristine();
                    f.$setUntouched();
                }, err => {
                    $scope.apiMessage = "Data update failed!!";
                });
        }
        $scope.delModal = null;
        $scope.confirmDelete = (mc) => {
            $scope.delModal = new bootstrap.Modal(document.getElementById('delModal'), {});
            $scope.current = mc;
            $scope.delModal.show();
        }
        $scope.doDeleteType = () => {
            console.log("del");
            console.log($scope.current);
            apiService.delete(`${apiUrl}Medicines/`, $scope.current.id)
                .then(res => {
                    var i = $scope.model.medicines.findIndex(mc => mc.id == $scope.current.id);
                    $scope.model.medicines.splice(i, 1);
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