import http from "k6/http";
import { sleep } from "k6";
export const options = {
  vus: 1000,
  duration: "5s",
};
export default function () {
  http.get("http://localhost:5134/WeatherForecast_2?searchKeyWord=Bra");
}
