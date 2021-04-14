import { Record } from "immutable";
import ShopItem from "../interfaces/shop-item";

const defaultValues: ShopItem = {
    description: "",
    title: "",
};

export default class ShopItemRecord extends Record(defaultValues) implements ShopItem {
    // -----------------------------------------------------------------------------------------
    // #region Properties
    // -----------------------------------------------------------------------------------------

    // Do NOT set properties on immutable records due to babel and typescript transpilation issue
    // See https://github.com/facebook/create-react-app/issues/6506

    // #endregion Properties

    // -----------------------------------------------------------------------------------------
    // #region Constructor
    // -----------------------------------------------------------------------------------------

    constructor(params?: ShopItem) {
        if (params == null) {
            params = Object.assign({}, defaultValues);
        }

        super(params);
    }

    // #endregion Constructor

    // -----------------------------------------------------------------------------------------
    // #region Public Methods
    // -----------------------------------------------------------------------------------------

    /**
     * Merges new values into the record and returns a new instance.
     *
     * @param {Partial<ShopItem>} values
     * @returns {ShopItemRecord}
     * @memberof ShopItemRecord
     */
    public with(values: Partial<ShopItem>): ShopItemRecord {
        return new ShopItemRecord(Object.assign(this.toJS(), values));
    }

    // #endregion Public Methods
}
