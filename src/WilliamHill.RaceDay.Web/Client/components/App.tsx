import * as React from "react";
import Loadable from "react-loadable";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import Layout from "./Layout";
import Loading from "./Loading";
import NotFound from "./NotFound";
import Home from "./Home";

const Races = Loadable({
    loader: () => import("../views/races"),
    loading: Loading
});

const Customers = Loadable({
    loader: () => import("../views/customers"),
    loading: Loading
});

class App extends React.Component {
    render() {
        return (
            <BrowserRouter>
                <Layout>
                    <Switch>
                        <Route exact path="/" component={Home}/>
                        <Route path="/races" component={Races}/>
                        <Route path="/customers" component={Customers}/>
                        <Route component={NotFound}/>
                    </Switch>
                </Layout>
            </BrowserRouter>
        );
    }
}

export default App;