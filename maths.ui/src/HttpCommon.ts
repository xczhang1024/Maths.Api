import axios from "axios";

/** Axios configuration */
export default axios.create({
  baseURL: "https://localhost:5001/api",
  headers: {
    "Content-type": "application/json"
  }
});