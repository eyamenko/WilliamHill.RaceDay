import * as React from "react";
import {inject, observer} from "mobx-react";
import {CounterStore} from "../store";

interface IProps {
    counterStore?: CounterStore;
}

@inject("counterStore")
@observer
class Counter extends React.Component<IProps> {
    counterStore: CounterStore;

    constructor(props: IProps) {
        super(props);

        this.counterStore = props.counterStore!;
    }

    render() {
        return (
            <div className="text-center">
                <div>{this.counterStore.count}</div>
                <div className="btn-group" role="group">
                    <button type="button" className="btn btn-secondary" onClick={() => this.counterStore.increment()}>
                        increment
                    </button>
                    <button type="button" className="btn btn-secondary" onClick={() => this.counterStore.decrement()}>
                        decrement
                    </button>
                </div>
            </div>
        );
    }
}

export default Counter;