angular.module('umbraco').controller('FlexibleList.Controller', function ($scope, $http, $routeParams) {
    $scope.items = [];

    console.log($scope);
    console.log($scope.model);
    console.log($routeParams);

    $http.get('Backoffice/FlexibleList/Datasource/Query', { params: { currentNodeId: $routeParams.id, propertyAlias: $scope.model.alias, providerName: $scope.model.config.listprovider } })
    .success(function (data, status) {
        var values = $scope.model.value ? $scope.model.value.toString().split(',') : [];
        angular.forEach(data, function (value) {
            var checked = _.contains(values, value.Value);
            $scope.items.push({
                value: value.Value,
                text: value.Text,
                checked: checked
            });
        });
    });

    $scope.change = function () {

        var values = [];
        angular.forEach($scope.items, function (value) {
            if (value.checked) {
                values.push(value.value);
            }
        });
        $scope.model.value = values.join(',');
        console.log($scope.model);
    }
});