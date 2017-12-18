import {action, observable} from "mobx";

export class Store {
    @observable
    navbarOpen: boolean = false;

    @action
    toggleNavbar() {
        this.navbarOpen = !this.navbarOpen;
    }
}

export default new Store();