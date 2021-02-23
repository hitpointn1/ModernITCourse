const utils = (function () {

    function updateTableData(data) {
        const tbody = $('#uni_table');
        const trs = tbody.children('tr');
        let i = 0;
        for (; i < data.length; i++) {
            const tr = trs[i];
            const dataItem = data[i];
            if (tr) {
                replaceTrData($(tr), dataItem)
                continue;
            }

            const newTr = document.createElement('tr');
            renderTd(newTr, dataItem.id);
            renderTd(newTr, dataItem.name);
            renderTd(newTr, dataItem.city);
            renderTd(newTr, dataItem.rating);
            tbody.append(newTr);
        }
        if (i - 1 < trs.length) {
            for (; i < trs.length; i++) {
                $(trs[i]).remove();
            }
        }
    }

    function replaceTrData(tr, data) {
        const tds = tr.children('td');
        tds[0].innerText = data.id;
        tds[1].innerText = data.name;
        tds[2].innerText = data.city;
        tds[3].innerText = data.rating;
    }

    function renderTd(tr, text) {
        const td = document.createElement('td');
        $(td).text(text);
        tr.append(td);
    }

    function updateUniversities() {
        fetch('/update', { method: 'PUT' });
    }

    return {
        updateTableData,
        updateUniversities
    }
})();

const simpleDynamicModule = (function () {
    function init() {
        refreshTable();
        attachEvents();
    }

    function attachEvents() {
        $('#uni_refresh').on('click', refreshTable);
        $('#uni_update').on('click', utils.updateUniversities);
    }

    function refreshTable() {
        $('#uni_table').parent().fadeOut(renderData);
        $('#uni_refresh').fadeOut();
        $('#uni_update').fadeOut();
    }

    function renderData() {
        $.getJSON('/api/vsu', function (data) {
            utils.updateTableData(data);
            $('#uni_refresh').fadeIn();
            $('#uni_update').fadeIn();
            $('#uni_table').parent().fadeIn();
        });
    }

    return {
        init: init,
    };
})();

const refreshDynamicModule = (function () {
    function init() {
        refreshTable();
        setInterval(refreshTable, 2000);
        attachEvents();
    }

    function attachEvents() {
        $('#uni_update').on('click', utils.updateUniversities);
    }

    function refreshTable() {
        $.getJSON('/api/vsu', function (data) {
            utils.updateTableData(data);
            $('#uni_update').fadeIn();
            $('#uni_table').parent().fadeIn();
        });
    }

    return {
        init: init,
    };
})();

const longPoolingModule = (function () {
    function init() {
        refreshTable();
        attachEvents();
    }

    function attachEvents() {
        $('#uni_update').on('click', utils.updateUniversities);
    }

    function refreshTable() {
        poll(null);
    }

    function poll(timestamp) {
        fetch('/api/vsu',
            {
                method: 'POST',
                body: JSON.stringify({ timeStamp: timestamp }),
                headers: {
                    'Accept': 'application/json, text/plain',
                    'Content-Type': 'application/json;charset=UTF-8'
                },
            })
            .then(response => {
                if (response.status === 200) {
                    response.json().then(json => {

                        utils.updateTableData(json.universities);
                        $('#uni_update').fadeIn();
                        $('#uni_table').parent().fadeIn();

                        if (!json.isFinished) {
                            poll(json.timeStamp)
                        }
                    });
                    return;
                }
                if (response.status === 204) {
                    poll(timestamp);
                }
            })
            .catch(_ => setTimeout(() => poll(timestamp), 30000));
    }

    return {
        init: init,
    };
})();
