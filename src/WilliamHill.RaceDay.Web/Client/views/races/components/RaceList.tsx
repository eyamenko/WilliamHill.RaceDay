import * as React from "react";
import {RaceStore} from "../store";
import Race from "../models/race";
import {inject, observer} from "mobx-react";
import Loader from "../../../components/Loader";

interface IRaceListProps {
    raceStore: RaceStore;
}

interface IRaceItemProps {
    race: Race;
}

function RaceItem(props: IRaceItemProps) {
    return (
        <tr>
            <td>{props.race.id}</td>
            <td>{props.race.status}</td>
            <td>${props.race.totalAmount}</td>
            <td>Horses</td>
        </tr>
    );
}

@inject("raceStore")
@observer
class RaceList extends React.Component {
    store: RaceStore;

    constructor(props: IRaceListProps) {
        super(props);

        this.store = props.raceStore!;
    }
    
    componentDidMount() {
        this.store.fetchRaces();
    }

    render() {
        if (this.store.loading) {
            return <Loader/>;
        }

        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Status</th>
                        <th>Total Amount</th>
                        <th>Horses</th>
                    </tr>
                </thead>
                <tbody>
                    {this.store.races.map(r => <RaceItem key={r.id} race={r}/>)}
                </tbody>
            </table>
        );
    }
}

export default RaceList;