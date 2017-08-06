var rangedWeaponComponent = new Vue({
    el: "#ranged",
    data: {
        weapons: [],
        distance: 100,
        count: 0
    },
    methods: {
        onInfinite: function () {
            var self = this;

            setTimeout(function () {
                var filter = JSON.stringify({ Type: "ranged", "Position": self.count, "Limit": 10 });
                $.ajax({
                    url: "/api/weaponapi/search",
                    contentType: "application/json",
                    method: "POST",
                    dataType: "json",
                    data: filter,
                }).done(function (data) {
                    for (var i = 0; i < data.length; i++) {
                        self.weapons.push(data[i]);
                        self.count++;
                    }

                    if (data.length == 0 || data.length < 10) {
                        self.$refs.infiniteLoading.$emit('$InfiniteLoading:complete');
                    } else {
                        self.$refs.infiniteLoading.$emit('$InfiniteLoading:loaded');
                    }
                }).fail(function (result) {
                    console.log(result);
                    self.$refs.infiniteLoading.$emit('$InfiniteLoading:loaded');
                });
            }.bind(self), 1000);
        }
    }
});

var meleeWeapon = new Vue({
    el: "#meele",
    data: {
        weapons: [],
        distance: 100,
        count: 0
    },
    methods: {
        onInfinite: function () {
            var self = this;

            setTimeout(function () {
                var filter = JSON.stringify({ Type: "meele", "Position": self.count, "Limit": 10 });
                $.ajax({
                    url: "/api/weaponapi/search",
                    contentType: "application/json",
                    method: "POST",
                    dataType: "json",
                    data: filter,
                }).done(function (data) {
                    for (var i = 0; i < data.length; i++) {
                        self.weapons.push(data[i]);
                        self.count++;
                    }

                    if (data.length == 0 || data.length < 10) {
                        self.$refs.infiniteLoading.$emit('$InfiniteLoading:complete');
                    } else {
                        self.$refs.infiniteLoading.$emit('$InfiniteLoading:loaded');
                    }
                }).fail(function (result) {
                    console.log(result);
                    self.$refs.infiniteLoading.$emit('$InfiniteLoading:loaded');
                });
            }.bind(self), 1000);
        }
    }
});