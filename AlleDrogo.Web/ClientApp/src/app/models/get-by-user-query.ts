import { QueryType } from "./query-type";

export class GetByUserQuery {

  constructor(queryType: QueryType, username: string) {
    this.queryType = queryType;
    this.username = username;
  }

  queryType: QueryType;
  username: string;
}
