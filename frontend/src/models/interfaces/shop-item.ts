import Auditable from "./auditable";

export default interface ShopItem extends Auditable {
    description?: string;
    title?: string;
}
