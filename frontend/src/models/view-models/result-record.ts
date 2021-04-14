import { Record } from "immutable";
import Result from "../interfaces/result";

const defaultValues: Result<any> = {
    errors: undefined,
    resultObject: undefined,
};

export default class ResultRecord<T> extends Record(defaultValues)
    implements Result<T> {

    // -----------------------------------------------------------------------------------------
    // #region Constructor
    // -----------------------------------------------------------------------------------------

    constructor(params?: Result<T>) {
        if (params == null) {
            params = Object.assign(defaultValues, params);
        }

        if (params.errors != null) {
            const errors = params.errors as any[];
            params.errors = errors.map((error) =>
                console.log(error)
            );
        }

        super(params);
    }

    // #endregion Constructor

    // -----------------------------------------------------------------------------------------
    // #region Public Methods
    // -----------------------------------------------------------------------------------------

    // #endregion Private Methods
}
