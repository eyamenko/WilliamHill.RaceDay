import * as React from "react";
import {RaceStore} from "../store";
import Race from "../models/race";
import {inject, observer} from "mobx-react";
import Loader from "../../../components/Loader";
import Horse from "../models/horse";

interface IRaceListProps {
    raceStore: RaceStore;
}

interface IRaceItemProps {
    race: Race;
}

interface IHorseItemProps {
    horse: Horse;
}

function HorseItem(props: IHorseItemProps) {
    return (
        <tr>
            <td>{props.horse.id}</td>
            <td>{props.horse.name}</td>
            <td>{props.horse.totalBets}</td>
            <td>${props.horse.totalPayout}</td>
        </tr>
    );
}

class RaceItem extends React.Component<IRaceItemProps> {
    get statusString() {
        switch (this.props.race.status) {
            case 0:
                return "Completed";
            case 1:
                return "In-Progress";
            case 2:
                return "Pending";
            default:
                return "";
        }
    }
    
    render() {
        return (
            <tr>
                <td>{this.props.race.id}</td>
                <td>{this.statusString}</td>
                <td>${this.props.race.totalAmount}</td>
                <td>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Total Bets</th>
                                <th>Total Payout</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.props.race.horses.map(h => <HorseItem key={h.id} horse={h}/>)}
                        </tbody>
                    </table>
                </td>
            </tr>
        );
    }
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