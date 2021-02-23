let es;

const sseModule = (function () {
    const apiAddress = 'api/execute';
    function init() {
        attachEvents();
    }

    function attachEvents() {
        $('#button-container > button').on('click', execute);
    }

    function execute(event) {
        const executeButton = $(event.target);
        const progressBar = $('#progress-bar');
        const progressMessage = $('#progress-message');

        progressMessage.text('');
        progressBar.width(0);
        executeButton.prop('disabled', true);

        es = new EventSource(apiAddress);
        es.onmessage = (event) => {
            const json = JSON.parse(event.data);
            progressMessage.text(json.Message);
            progressBar.width(json.Load + '%');
            if (json.IsFinished) {
                es.close();
                executeButton.prop('disabled', false);
            }
        };
    }

    return {
        init: init,
    };
})();

$(document).ready(() => {
    sseModule.init();
});
