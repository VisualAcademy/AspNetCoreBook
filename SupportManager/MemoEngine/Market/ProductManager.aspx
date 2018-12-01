<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManager.aspx.cs" Inherits="MemoEngine.Market.ProductManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container" ng-app="productManager">
        <div class="panel panel-primary" ng-controller="ProductListController as vm">
            <div class="panel-heading">
                {{ vm.title }}
            </div>
            <div class="panel-body">
                <table class="table">
                    <thead>
                        <tr>
                            <td>
                                상품명
                            </td>
                            <td>
                                상품코드
                            </td>
                            <td>
                                가격
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr ng-repeat="product in vm.products">
                            <td>{{ product.modelName }}</td>
                            <td>{{ product.productId }}</td>
                            <td>{{ product.sellPrice }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script src="/Scripts/angular.js"></script>
    <script>
        (function () {
            'use strict';

            angular.module('productManager', []);

        })();

        (function () {
            'use strict';

            angular
                .module('productManager')
                .controller('ProductListController', ProductListController);            

            function ProductListController($http) {
                
                var vm = this;
                vm.title = '상품 리스트';
                
                $http.get("/api/Products").success(function (data) {
                    vm.products = data; 
                });

                //// 아래 데이터는 실제로는 RESTful 서비스는 Web API로부터 JSON 데이터를 받아서 처리
                //vm.products = [
                //    { "productId": 1, "modelName": "좋은 책", "sellPrice": 1000 },
                //    { "productId": 2, "modelName": "좋은 컴퓨터", "sellPrice": 2000 },
                //    { "productId": 3, "modelName": "좋은 강의", "sellPrice": 3000 }
                //];


                activate();

                function activate() { }
            }
        })();
    </script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
