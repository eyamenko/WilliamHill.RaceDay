import * as React from "react";
import counterStore from "./store";
import {Provider} from "mobx-react";
import Counter from "./components/Counter";

export default () => (
    <Provider counterStore={counterStore}>
        <Counter/>
    </Provider>
);