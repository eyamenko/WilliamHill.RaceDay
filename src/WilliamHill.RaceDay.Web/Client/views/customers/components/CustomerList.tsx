import * as React from "react";
import {CustomerStore} from "../store";
import {inject, observer} from "mobx-react";
import Loader from "../../../components/Loader";
import Customer from "../models/customer";

interface ICustomerListProps {
    customerStore: CustomerStore;
}

interface ICustomerItemProps {
    customer: Customer;
}

function CustomerItem(props: ICustomerItemProps) {
    return (
        <tr>
            <td>{props.customer.id}</td>
            <td>{props.customer.totalBets}</td>
            <td>${props.customer.totalAmountBet}</td>
            <td>{props.customer.isRisky ? "+" : ""}</td>
        </tr>
    );
}

@inject("customerStore")
@observer
class CustomerList extends React.Component {
    store: CustomerStore;

    constructor(props: ICustomerListProps) {
        super(props);

        this.store = props.customerStore!;
    }
    
    componentDidMount() {
        this.store.fetchCustomers();
    }

    render() {
        if (this.store.loading || !this.store.customerList) {
            return <Loader/>;
        }

        return (
            <div>
                <h3>Total Amount Bet: ${this.store.customerList.totalAmountBet}</h3>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Total Bets</th>
                            <th>Total Amount Bet</th>
                            <th>Is Risky</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.store.customerList.customers.map(c => <CustomerItem key={c.id} customer={c}/>)}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default CustomerList;