import * as React from "react";
import Loadable from "react-loadable";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import Layout from "./Layout";
import Loading from "./Loading";
import NotFound from "./NotFound";
import Home from "./Home";

const Counter = Loadable({
    loader: () => import("../views/counter"),
    loading: Loading
});

class App extends React.Component {
    render() {
        return (
            <BrowserRouter>
                <Layout>
                    <Switch>
                        <Route exact path="/" component={Home}/>
                        <Route path="/counter" component={Counter}/>
                        <Route component={NotFound}/>
                    </Switch>
                </Layout>
            </BrowserRouter>
        );
    }
}

export default App;