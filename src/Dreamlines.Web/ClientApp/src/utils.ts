import * as moment from "moment";

const numberSeparatorRegex = /\d(?=(\d{3})+\.)/g;
const numberSeparator = "$&,";

export const formatNumber = (value: number, fractionDigits = 3) =>
    value.toFixed(fractionDigits).replace(numberSeparatorRegex, numberSeparator);

export const toIsoDate = (date: Date) =>
    moment(date).format("YYYY-MM-DD");

export const toUSDate = (date: Date) =>
    moment(date).format("MM/DD/YYYY");