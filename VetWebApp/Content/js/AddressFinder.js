(function () {
    var widget, initAddressFinder = function () {
        widget = new AddressFinder.Widget(
            document.getElementById('suburb'),
            'ADDRESSFINDER_DEMO_KEY',
            'AU',
            {
                show_addresses: false,
                show_locations: true,
                location_params: {
                    location_types: "locality, state",
                },
            }
        );
        widget.on('result:select', function (fullAddress, metaData) {
            document.getElementById('suburb').value = metaData.locality_name;
            document.getElementById('postcode').value = metaData.postcode;
        });
    };

    function downloadAddressFinder() {
        var script = document.createElement('script');
        script.src = 'https://api.addressfinder.io/assets/v3/widget.js';
        script.async = true;
        script.onload = initAddressFinder;
        document.body.appendChild(script);
    };

    document.addEventListener('DOMContentLoaded', downloadAddressFinder);
})();