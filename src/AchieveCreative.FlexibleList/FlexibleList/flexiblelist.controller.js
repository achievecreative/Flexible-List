angular.module('umbraco').controller('FlexibleList.Controller', function ($scope, $http, $routeParams) {

    $scope.model.config.maximum = parseInt($scope.model.config.maximum || 0);

    $scope.items = [];

    //console.log($scope);
    //console.log($scope.model);
    //console.log($routeParams);

    $http.get('Backoffice/FlexibleList/Datasource/Query',{
             params: {
                 currentNodeId: $routeParams.id,
                 propertyAlias: $scope.model.alias,
                 providerName: $scope.model.config.listprovider
             }
       })
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

    $scope.change = function (index) {
        return $scope.model.config.maximum === 1 ? onlyOne(index) : multiple(index);
    }

    $scope.totalSelected = function () {
        var total = 0;
        angular.forEach($scope.items, function (value) {
            if (value.checked) {
                total++;
            }
        });

        return total;
    }

    function onlyOne(index) {
        angular.forEach($scope.items, function (value, $index) {
            if (index != $index) {
                value.checked = false;
            }
        });

        $scope.model.value = $scope.items[index].checked ? $scope.items[index].value : '';
    }

    function multiple(index) {
        if ($scope.model.config.maximum != 0 && $scope.items[index].checked) {
            if ($scope.totalSelected() > $scope.model.config.maximum) {
                $scope.items[index].checked = false;
                alert("Only able to select " + $scope.model.config.maximum + " item(s) at maximum.");
                return;
            }
        }

        var values = [];
        angular.forEach($scope.items, function (value) {
            if (value.checked) {
                values.push(value.value);
            }
        });
        $scope.model.value = values.join(',');
        //console.log($scope.model);
    }
});