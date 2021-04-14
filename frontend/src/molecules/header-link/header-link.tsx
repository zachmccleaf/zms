import { Link } from 'react-router-dom';

// -----------------------------------------------------------------------------------------
// #region Intefaces
// -----------------------------------------------------------------------------------------

interface HeaderLinkProps {
    page: any;
}

// #endregion Intefaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const HeaderLink: React.FC<HeaderLinkProps> = (props: HeaderLinkProps) => {
    const title = props.page.charAt(0).toUpperCase() + props.page.slice(1);
    let link = null;

    if (props.page === "home") {
        link = <Link to={`/`}>{title}</Link>;
    } else {
        link =  <Link to={`/${props.page}`}>{title}</Link>;
    }

    return (
        <div className="m-header-link">
            {link}
        </div>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Exports
// -----------------------------------------------------------------------------------------

export default HeaderLink;

// #endregion Exports
