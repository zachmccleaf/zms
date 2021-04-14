import axios from "axios";
import ShopItemRecord from "../../models/view-models/shop-item-record";
import ServiceFactory from "../service-factory";

// -------------------------------------------------------------------------------------------------
// #region Interfaces
// -------------------------------------------------------------------------------------------------


export interface ShopItemPathParams {
    id: number;
}

// #endregion Interfaces

// -------------------------------------------------------------------------------------------------
// #region Constants
// -------------------------------------------------------------------------------------------------

const resourceType = ShopItemRecord;
const baseEndpoint = "shopitems";
const resourceEndpoint = `${baseEndpoint}/:id`;

// #endregion Constants

// -------------------------------------------------------------------------------------------------
// #region Service
// -------------------------------------------------------------------------------------------------

const ShopItemService = {
   /**
     * Retrieve an item by id
     */
    get: ServiceFactory.get<ShopItemRecord, ShopItemPathParams>(
        resourceType,
        resourceEndpoint
    ),

    /**
     * Retrieve a a list of all items matching given parameters
     */
    list: ServiceFactory.list<ShopItemRecord, ShopItemPathParams>(
        resourceType,
        baseEndpoint
    ),

};

// #endregion Service

// -------------------------------------------------------------------------------------------------
// #region Exports
// -------------------------------------------------------------------------------------------------

export default ShopItemService;

// #endregion Exports
