import * as React from "react";
import customerStore from "./store";
import {Provider} from "mobx-react";
import CustomerList from "./components/CustomerList";

export default () => (
    <Provider customerStore={customerStore}>
        <CustomerList/>
    </Provider>
);