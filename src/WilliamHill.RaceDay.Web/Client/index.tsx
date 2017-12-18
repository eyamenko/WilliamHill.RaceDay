import * as React from "react";
import * as ReactDOM from "react-dom";
import * as mobx from "mobx";
import {Provider} from "mobx-react";
import store from "./store";

mobx.useStrict(true);

const render = () => {
    const App = require("./components/App").default;

    ReactDOM.render(
        <Provider store={store}>
            <App/>
        </Provider>,
        document.getElementById("root")
    );
};

render();

module.hot && module.hot.accept("./components/App", render);