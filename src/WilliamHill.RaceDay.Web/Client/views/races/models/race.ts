import Horse from "./horse";

interface Race {
    id: number;
    status: number;
    totalAmount: number;
    horses: Array<Horse>
}

export default Race;