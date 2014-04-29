angular.module('umbraco').controller('FlexibleList.Datasource.Controller', function ($scope, $http) {

    $scope.providers = [];

    $http.get('Backoffice/FlexibleList/ListProdiver/GetAll').then(function (rsp) {
        angular.forEach(rsp.data, function(value) {
            $scope.providers.push(value);
        });
    });

    $scope.isSelected = function(value) {
        return value === $scope.model.value;
    }
});