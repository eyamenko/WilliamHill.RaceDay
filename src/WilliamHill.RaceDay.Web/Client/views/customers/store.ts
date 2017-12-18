import {action, observable, runInAction} from "mobx";
import CustomerList from "./models/customerList";

export class CustomerStore {
    @observable
    loading: boolean = false;
    @observable
    customerList: CustomerList;

    @action
    async fetchCustomers() {
        this.loading = true;

        const response = await fetch("/api/customers");
        const json = await response.json();

        runInAction(() => {
            this.loading = false;
            this.customerList = json;
        });
    }
}

export default new CustomerStore();