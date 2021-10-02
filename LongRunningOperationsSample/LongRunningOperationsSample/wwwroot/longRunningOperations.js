export default context => new LongRunningOperationsModule(context);

class LongRunningOperationsModule {

    constructor(context) {
        this.context = context;

        this.viewModel = ko.dataFor(context.elements[0]);
        this.viewModel.OperationId.subscribe(() => this._subscribe());

        this._init();
    }

    async _init() {
        this.connection = new signalR.HubConnectionBuilder().withUrl("/hub/dotvvm/longRunningOperations").build();
        this.connection.on("newStatus", status => this._onNewStatus(status));
        await this.connection.start();
        await this._subscribe();
    }

    async _subscribe() {
        await this.connection.invoke("subscribe", this.viewModel.OperationId());
    }

    async $dispose() {
        await this.connection.stop();
    }

    _onNewStatus(status) {
        this.viewModel.ProgressPercent(status.progressPercent);
        this.viewModel.Status(status.status);
        this.viewModel.IsCompleted(status.isCompleted);
        this.viewModel.HasError(status.hasError);
    }

}