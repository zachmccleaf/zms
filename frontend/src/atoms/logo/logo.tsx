import React from "react";
import HeaderLink from "../../molecules/header-link/header-link";

// -----------------------------------------------------------------------------------------
// #region Interfaces
// -----------------------------------------------------------------------------------------

interface LogoProps {}

// #endregion Interfaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const Logo: React.FC<LogoProps> = (
    props: LogoProps
) => {
    return (
        <div className='a-logo'>
        </div>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Export
// -----------------------------------------------------------------------------------------

export default Logo;

// #endregion Export
