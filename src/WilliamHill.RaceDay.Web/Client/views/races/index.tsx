import * as React from "react";
import raceStore from "./store";
import {Provider} from "mobx-react";
import RaceList from "./components/RaceList";

export default () => (
    <Provider raceStore={raceStore}>
        <RaceList/>
    </Provider>
);