import {action, observable, runInAction} from "mobx";
import Race from "./models/race";

export class RaceStore {
    @observable
    loading: boolean = false;
    @observable
    races: Array<Race> = [];

    @action
    async fetchRaces() {
        this.loading = true;

        const response = await fetch("/api/races");
        const json = await response.json();

        runInAction(() => {
            this.loading = false;
            this.races = json;
        });
    }
}

export default new RaceStore();