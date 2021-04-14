import axios from "axios";
import ServiceResponse from "./interfaces/service-response";


// -----------------------------------------------------------------------------------------
// #region Types
// -----------------------------------------------------------------------------------------

/**
 * Type defining the service function for getting the supplied resource type
 */
export type GetService<TPathParams, TQueryParams = undefined> = (
    pathParams: TPathParams,
    queryParams?: TQueryParams
) => Promise<void>;

/**
 * Type defining the service function for listing resources by supplied type
 */
export type ListService<TQueryParams> = (
    queryParams?: TQueryParams
) => Promise<void>;

// #endregion Types


// ---------------------------------------------------------------------------------------------
// #region Public Functions
// ---------------------------------------------------------------------------------------------

/**
 * Factory to encapsulate common service function logic
 */
const ServiceFactory = {
    /**
     * Creates conventional Service Get function for the supplied resource type
     * @param recordType
     * @param resourceEndpoint
     */
    get<TRecord, TPathParams, TQueryParams = undefined>(
        recordType: { new (): TRecord },
        resourceEndpoint: string
    ): GetService<TPathParams, TQueryParams> {
        return async (pathParams: TPathParams, queryParams?: TQueryParams) =>
            await _get<TRecord, TPathParams, TQueryParams>(
                recordType,
                resourceEndpoint,
                pathParams,
                queryParams
            );
    },

    /**
     * Creates conventional Service List function for the supplied resource type
     *
     * ### Recommendation
     * Use `nestedList` when route is nested!
     *
     * @param recordType
     * @param baseEndpoint
     */
    list<TRecord, TQueryParams>(
        recordType: { new (): TRecord },
        baseEndpoint: string
    ): ListService<TQueryParams> {
        return async (queryParams?: TQueryParams) =>
            await _list<TRecord>(recordType, baseEndpoint, null, queryParams);
    },
};

// #endregion Public Functions

// ---------------------------------------------------------------------------------------------
// #region Private Functions
// ---------------------------------------------------------------------------------------------

const _get = async function<TRecord, TPathParams, TQueryParams = undefined>(
    recordType: { new (): TRecord },
    resourceEndpoint: string,
    pathParams: TPathParams,
    queryParams?: TQueryParams
) {
    const url = resourceEndpoint;
    return await axios
        .get(url)
        .then(res => {
            const data = res.data;
            console.log(data)
        });
};

const _list = async function<TRecord extends any>(
    recordType: { new (): TRecord },
    baseEndpoint: string,
    pathParams?: any,
    queryParams?: any
) {
    const url = baseEndpoint;
    return await axios
        .get(url)
        .then(res => {
            const data = res.data;
            console.log(data)
        })
};

// #endregion Private Functions

// ---------------------------------------------------------------------------------------------
// #region Exports
// ---------------------------------------------------------------------------------------------

export default ServiceFactory;

// #endregion Exports
