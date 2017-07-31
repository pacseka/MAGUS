
var weaponvue = new Vue({
    el: '#weaponvue',
    data: {
        weapons: []
    },
    methods: {
        Init: function (dataModel) {
            $("#tbMeleeWeapon").dataTable({
                "ajax": {
                    "url": dataModel.weaponUrl + "/search",
                    "dataSrc": "",
                    "type": "POST",
                    "contentType": "application/json",
                    "dataType": "json",
                    "data": function () { return JSON.stringify({ Name: "Kahrei", Initiate: { Min: 0, Max: 10 } }); }
                },
                "columns": [
                    { "data": "Name" },
                    { "data": "Initiate" },
                    { "data": "Cost" }
                ]
            });
        },

        FindWeapon: function () {
            var vm = this;
            var filter = JSON.stringify({ Name: "Kahrei", Initiate: { Min: 0, Max: 10 } });
            $.ajax({
                url: dataModel.weaponUrl + "/search",
                contentType: "application/json",
                method: "POST",
                dataType: "json",
                data: filter,
            }).done(function (data) {
                vm.weapons = data;
            }).fail(function (result) {
                console.log(result);
            });
        }
    }
});

var dataModel = new AppDataModel();

weaponvue.Init(dataModel);